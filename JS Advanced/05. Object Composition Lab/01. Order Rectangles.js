function orderRectangles(input) {
    function createRect(width, height){
        let rect =  {
            width: width,
            height: height,
            area: function () {
               return rect.width * rect.height;
            },
            compareTo: function(other) {
                return other.area() - rect.area() || other.width - rect.width;
            }
        };

        return rect;
    }

    let rects = [];
    for(let [width, height] of input){
        rects.push(createRect(width, height));
    }

    let sortedRects = rects.sort((a, b) => a.compareTo(b));
    return sortedRects;
}
