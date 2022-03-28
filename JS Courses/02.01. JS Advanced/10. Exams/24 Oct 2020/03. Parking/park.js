class Parking {
    constructor(capacity) {
        this.capacity = capacity;
        this.vehicles = [];
        this.parkingSpots = 0;
    }

    addCar(carModel, carNumber) {

        if (this.parkingSpots == this.capacity) {
            throw new Error(`Not enough parking space.`);
        }

        let car = {
            carModel,
            carNumber,
            payed: 'false'
        }

        this.vehicles.push(car);
        this.parkingSpots++;
        return `The ${car.carModel}, with a registration number ${car.carNumber}, parked.`;
    }

    removeCar(carNumber) {
        let car = this.vehicles.find(x => x.carNumber == carNumber);

        if (!car) {
            throw new Error(`The car, you're looking for, is not found.`);
        }

        if (car.payed == 'false') {
            throw new Error(`${car.carNumber} needs to pay before leaving the parking lot.`);
        }

        this.vehicles.splice(1, 0, car);
        this.parkingSpots--;

        return `${car.carNumber} left the parking lot.`;
    }

    pay(carNumber) {
        let car = this.vehicles.find(x => x.carNumber == carNumber);

        if (!car) {
            throw new Error(`${carNumber} is not in the parking lot.`);
        }

        if (car.payed == 'true') {
            throw new Error(`${car.carNumber}'s driver has already payed his ticket.`);
        }

        car.payed = 'true';

        return `${car.carNumber}'s driver successfully payed for his stay.`;
    }

    getStatistics(carNumber) {
        if (!carNumber) {
            let result = `The Parking Lot has ${this.capacity - this.parkingSpots} empty spots left.`;
            this.vehicles.sort((a, b) => a.carModel.localeCompare(b.carModel));
            for (let i = 0; i < this.vehicles.length; i++) {
                let currentCar = this.vehicles[i];
                result += '\n';
                result += `${currentCar.carModel} == ${currentCar.carNumber} - ${currentCar.payed == "true" ? `Has payed` : `Not payed`}`;
            }
            return result;
        }
        else {
            let car = this.vehicles.find(x => x.carNumber == carNumber);
            return `${car.carModel} == ${car.carNumber} - ${car.payed == "true" ? `Has payed` : `Not payed`}`;
        }
    }
}