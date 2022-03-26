function vacation(groupOfPeople, typeOfPeople, day) {

    let stundetPerOne = 0;
    let businessPerOne = 0;
    let regularPerOne = 0;

    switch (day) {
        case "Friday":
            stundetPerOne = 8.45;
            businessPerOne = 10.90;
            regularPerOne = 15;
            break;
        case "Saturday":
            stundetPerOne = 9.80;
            businessPerOne = 15.60;
            regularPerOne = 20;
            break;
        case "Sunday":
            stundetPerOne = 10.46;
            businessPerOne = 16;
            regularPerOne = 22.50;
            break;
    }

    let finalPrice = 0;

    if (typeOfPeople == "Students") {
        finalPrice = groupOfPeople * stundetPerOne;
        if (groupOfPeople >= 30) {
            finalPrice = finalPrice - (finalPrice * 0.15);
        }
    }
    else if (typeOfPeople == "Business") {
        finalPrice = groupOfPeople * businessPerOne;
        if (groupOfPeople >= 100) {
            finalPrice = finalPrice - businessPerOne * 10;
        }
    }
    else if (typeOfPeople == "Regular") {
        finalPrice = groupOfPeople * regularPerOne;
        if (groupOfPeople >= 10 && groupOfPeople <= 20) {
            finalPrice = finalPrice - (finalPrice * 0.05);
        }

    }

    console.log(`Total price: ${finalPrice.toFixed(2)}`);
}

vacation(30,
    "Students",
    "Sunday"
)