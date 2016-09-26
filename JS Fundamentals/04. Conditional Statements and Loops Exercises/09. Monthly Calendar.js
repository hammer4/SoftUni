function monthlyCalendar([day, month, year]) {
    [day, month, year] = [day, month, year].map(Number);
    month--;
    let today = new Date(year, month, day);
    let dayOfWeek = new Date(year, month, 1).getDay();
    let html = '<table>\n';
    html += '<tr><th>Sun</th><th>Mon</th><th>Tue</th><th>Wed</th><th>Thu</th><th>Fri</th><th>Sat</th></tr>\n';
    let previousMonthDays = 0;
    html += '<tr>';
    let daysOfLastMonth = 0;

    if(dayOfWeek != 0) {
        let daysInLastMonth = new Date(year, month, 0).getDate();
        daysOfLastMonth = dayOfWeek;

        for(let i = 1; i<=daysOfLastMonth; i++) {
            html += `<td class="prev-month">${daysInLastMonth - daysOfLastMonth + i}</td>`;
            previousMonthDays ++;
        }
    }

    let currentMonthDays = 1;

    for(let i = previousMonthDays; i< 7; i++) {
        if(currentMonthDays == day) {
            html += `<td class="today">${currentMonthDays}</td>`;
        } else {
            html += `<td>${currentMonthDays}</td>`;
        }

        currentMonthDays++;
    }

    html += '</tr>\n';

    let counter = 0;
    for(let i = currentMonthDays; i<= new Date(year, month+1, 0).getDate(); i++) {
        if(counter %7 == 0) {
            html += '<tr>';
        }
        if(currentMonthDays == day) {
            html += `<td class="today">${currentMonthDays}</td>`;
        } else {
            html += `<td>${currentMonthDays}</td>`;
        }
        counter++;
        if(counter %7 == 0) {
            html += '</tr>\n';
        }
        currentMonthDays++;
    }

    let nextMonthDays = 1;

    for(let i = (daysOfLastMonth + currentMonthDays - 1) % 7; i < 7; i++) {
        if(i == 0) {
            html += "</table>\n";
            console.log(html);
            return;
        }
        html += `<td class="next-month">${nextMonthDays}</td>`;
        nextMonthDays++;
    }

    html += "</tr>\n";
    html += "</table>\n";

    console.log(html);
}
