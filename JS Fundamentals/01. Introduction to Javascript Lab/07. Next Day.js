function nextDay(arr) {
    let year = Number(arr[0]);
    let month = Number(arr[1]);
    let day = Number(arr[2]);

    let today = new Date(year, month-1, day);
    let oneDay = 24 * 60 * 60 * 1000;
    let nextDay = new Date(today.getTime() + oneDay);

    console.log(`${nextDay.getFullYear()}-${nextDay.getMonth()+1}-${nextDay.getDate()}`);
}
