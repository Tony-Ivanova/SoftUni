function movies(input) {

    let movies = [];

    for (let i = 0; i < input.length; i++) {
        let currentString = input[i];

        let phraseForAddMovie = 'addMovie';
        let phraseForDirector = 'directedBy';
        let phraseForDate = 'onDate';

        if (currentString.includes(phraseForAddMovie)) {
            let movieArr = currentString.match(/^(\S+)\s(.*)/).slice(1);
            let name = movieArr[1];
            let movie = { name: name };
            movies.push(movie);
        } else if (currentString.includes(phraseForDirector)) {
            let [name, director] = currentString.split(/\s*directedBy\s*/);
            let movie = movies.find(x => x.name === name);
            
            if (movie !== undefined) {
                movie.director = director;
            }
        } else if (currentString.includes(phraseForDate)) {
            let [name, date] = currentString.split(/\s*onDate\s*/);;
            let movie = movies.find(x => x.name === name);

            if (movie !== undefined) {
                movie.date = date;
            }
        }
    }

    for (const name in movies) {
        let movie = movies[name];
        
        if (
            movie.hasOwnProperty('name') &&
            movie.hasOwnProperty('date') &&
            movie.hasOwnProperty('director')
        ) {
            console.log(JSON.stringify(movie));
        }
    }
}

movies([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
]
)