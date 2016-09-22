function cone([radius, height]) {
    [radius, height] = [radius, height].map(Number);

    let volume = (Math.PI * Math.pow(radius, 2) * height) / 3;
    let area = Math.PI * radius * (radius + Math.sqrt(radius * radius + height * height));

    console.log(volume);
    console.log(area);
}
