namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writersDto = JsonConvert.DeserializeObject<ImportWritersDto[]>(jsonString);

            var sb = new StringBuilder();
            var validWriter = new List<Writer>();

            foreach (var writerDto in writersDto)
            {
                if (!IsValid(writerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var writer = new Writer
                {
                    Name = writerDto.Name,
                    Pseudonym = writerDto.Pseudonym
                };

                validWriter.Add(writer);
                sb.AppendLine(string.Format(SuccessfullyImportedWriter, writer.Name));
            }
            context.Writers.AddRange(validWriter);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producersAlbumsDto = JsonConvert.DeserializeObject<ImportProducersAlbumsDto[]>(jsonString);

            var sb = new StringBuilder();
            var validProducers = new List<Producer>();

            foreach (var producerDto in producersAlbumsDto)
            {
                if (!IsValid(producerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (producerDto.Albums != null && !producerDto.Albums.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var producer = new Producer
                {
                    Name = producerDto.Name,
                    Pseudonym = producerDto.Pseudonym,
                    PhoneNumber = producerDto.PhoneNumber
                };

                if (producerDto.Albums != null)
                {
                    foreach (var albumDto in producerDto.Albums)
                    {
                        if (!IsValid(albumDto))
                        {
                            sb.AppendLine(ErrorMessage);
                            break;
                        }

                        DateTime realeaseDateDto;
                        bool isReleaseDateValid = DateTime.TryParseExact(albumDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out realeaseDateDto);


                        if (!isReleaseDateValid)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }


                        producer.Albums.Add(new Album
                        {
                            Name = albumDto.Name,
                            ReleaseDate = realeaseDateDto
                        });
                    }
                }

                if (producer.PhoneNumber != null)
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber, producer.Albums.Count));
                }
                else
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count));
                }

                validProducers.Add(producer);
            }
            context.Producers.AddRange(validProducers);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSongsDto[]), new XmlRootAttribute("Songs"));
            var songsDtos = (ImportSongsDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var validSongs = new List<Song>();

            foreach (var songDto in songsDtos)
            {
                if (!IsValid(songDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime songCreatedOn;
                var isSongCreatedOnValid = DateTime.TryParseExact(songDto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out songCreatedOn);

                if (!isSongCreatedOnValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                TimeSpan songDuration;
                var isSongDurationValid = TimeSpan.TryParseExact(songDto.Duration, "c", CultureInfo.InvariantCulture, out songDuration);


                if (!isSongDurationValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Genre songGenre;

                var isSongGenreValid = Enum.TryParse(songDto.Genre, out songGenre);


                if (!isSongGenreValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var album = context.Albums.Find(songDto.AlbumId);
                var writer = context.Writers.Find(songDto.WriterId);

                if (album == null || writer == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var song = new Song
                {
                    Name = songDto.Name,
                    Duration = songDuration,
                    CreatedOn = songCreatedOn,
                    Genre = songGenre,
                    AlbumId = songDto.AlbumId,
                    WriterId = songDto.WriterId,
                    Price = songDto.Price,
                };

                validSongs.Add(song);
                sb.AppendLine(string.Format(SuccessfullyImportedSong, song.Name, song.Genre, song.Duration));
            }


            context.Songs.AddRange(validSongs);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSongPerformersDto[]), new XmlRootAttribute("Performers"));
            var perfomersDto = (ImportSongPerformersDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var validPerformers = new List<Performer>();

            foreach (var performerDto in perfomersDto)
            {
                if (!IsValid(performerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validSongsCount = context.Songs.Count(s => performerDto.PerformerSongs.Any(i => i.Id == s.Id));

                if (validSongsCount != performerDto.PerformerSongs.Length)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                var performer = new Performer
                {
                    FirstName = performerDto.FirstName,
                    LastName = performerDto.LastName,
                    Age = performerDto.Age,
                    NetWorth = performerDto.NetWorth,
                };

                foreach (var songDto in performerDto.PerformerSongs)
                {
                    if (!IsValid(songDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    performer.PerformerSongs.Add(new SongPerformer
                    {
                        SongId = songDto.Id
                    });
                }

                validPerformers.Add(performer);
                sb.AppendLine(string.Format(SuccessfullyImportedPerformer, performer.FirstName, performer.PerformerSongs.Select(x=>x.SongId).Count()));
            }

            context.Performers.AddRange(validPerformers);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            var result = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return result;
        }
    }
}