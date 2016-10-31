function tickets(ticketsArr, sortingCriteria) {
    class Ticket{
        constructor(destination, price, status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let unsortedTickets = [];

    for(let ticket of ticketsArr){
        let[destination, price, status] = ticket.split('|');
        price = Number(price);
        unsortedTickets.push(new Ticket(destination, price, status));
    }

    let sortedTckets;
    switch (sortingCriteria){
        case "destination":
            sortedTckets = unsortedTickets.sort((a, b) => a.destination.localeCompare(b.destination));
            break;
        case "price":
            sortedTckets = unsortedTickets.sort((a, b) => a.price - b.price);
            break;
        case "status":
            sortedTckets = unsortedTickets.sort((a, b) => a.status.localeCompare(b.status));
            break;
    }

    return sortedTckets;
}