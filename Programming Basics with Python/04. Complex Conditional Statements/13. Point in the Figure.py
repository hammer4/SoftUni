size = int(input())
pointX = int(input())
pointY = int(input())

lowerRectangleX1 = 0
lowerRectangleY1 = 0
lowerRectangleX2 = 3*size
lowerRectangleY2 = size

upperRectangleX1 = size
upperRectangleY1 = size
upperRectangleX2 = 2 * size
upperRectangleY2 = 4 * size

if pointX >= lowerRectangleX1 and pointX <= lowerRectangleX2 and pointY >= lowerRectangleY1 and pointY <= upperRectangleY2:
    if pointY < lowerRectangleY2:
        if pointY > lowerRectangleY1:
            if pointX > lowerRectangleX1 and pointX < lowerRectangleX2:
                print("inside")
            else:
                print("border")
        elif pointY == lowerRectangleY1:
            print("border")
    elif pointY == lowerRectangleY2:
        if pointX <= upperRectangleX1 or pointX >= upperRectangleX2:
            print("border")
        else:
            print("inside")
    else:
        if pointY < upperRectangleY2:
            if pointX > upperRectangleX1 and pointX < upperRectangleX2:
                print("inside")
            elif pointX == upperRectangleX1 or pointX == upperRectangleX2:
                print("border")
            else:
                print("outside")
        else:
            if pointX >= upperRectangleX1 and pointX <= upperRectangleX2:
                print("border")
            else:
                print("outside")
else:
    print("outside")