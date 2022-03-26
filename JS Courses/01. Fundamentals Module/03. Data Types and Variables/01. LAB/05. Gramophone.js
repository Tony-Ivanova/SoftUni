function gramophone(band, album, song) {

    let fullRotation = 2.5;

    let songDuration = (album.length * band.length) * song.length / 2;

    let nOfRotations = Math.ceil(songDuration / fullRotation);

    console.log(`The plate was rotated ${nOfRotations} times.`);
}

gramophone('Black Sabbath', 'Paranoid', 'War Pigs')