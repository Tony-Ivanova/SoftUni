function solve(args, sorting) {

    let tickets = [];

    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    args.forEach(line => {
        let [destination, priceInput, status] = line.split('|');
        let currentTicket = new Ticket(destination, Number(priceInput), status);
        tickets.push(currentTicket);
    });

    switch (sorting) {
        case "destination":
            tickets.sort(function (a, b) {
                if (a.destination < b.destination) {
                    return -1;
                }
                if (a.destination > b.destination) {
                    return 1;
                }
                return 0;
            });
            break;
        case "price":
            tickets.sort();
            break;
        case "status":
            tickets.sort(function (a, b) {
                if (a.status < b.status) {
                    return -1;
                }
                if (a.status > b.status) {
                    return 1;
                }
                return 0;
            });
            break;
        default:
            break;
    }

    return tickets;
}

solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'
)




