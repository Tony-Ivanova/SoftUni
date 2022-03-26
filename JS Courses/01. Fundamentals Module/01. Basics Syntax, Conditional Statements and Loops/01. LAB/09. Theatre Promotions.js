function theatrePromotion(typeOfDay, age) {
    let price = 0;
    let day = typeOfDay.toLowerCase();

    if (day == "weekday") {
        if ((age >= 0 && age <= 18) || (age > 64 && age <= 122)) {
            price = 12;
        }
        else if (age > 18 && age <= 64) {
            price = 18;
        }
    }
    else if (day == "weekend") {
        if ((age >= 0 && age <= 18) || (age > 64 && age <= 122)) {
            price = 15;
        }
        else if (age > 18 && age <= 64) {
            price = 20;
        }
    }
    else if (day == "holiday") {
        if (age >= 0 && age <= 18) {
            price = 5;
        }
        else if (age > 64 && age <= 122) {
            price = 10;
        }
        else if (age > 18 && age <= 64) {
            price = 12;
        }
    }
    if (price != 0) {
        console.log(`${price}$`);
    }
    else {
        console.log("Error!");
    }
}

theatrePromotion('Holiday', -12)