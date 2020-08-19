/*********************  Collision detection ******************** */
function CollisionDetector() {

}

CollisionDetector.isBubbleBorderCollides = function (circle, lineStart, lineEnd) {

    var p1 = Vector.sub(lineStart, circle.center);
    var p2 = Vector.sub(lineEnd, circle.center);

    var deltaLine = Vector.sub(lineEnd, lineStart);

    var a = deltaLine.X * deltaLine.X + deltaLine.Y * deltaLine.Y;
    var b = 2 * (p1.X * deltaLine.X + p1.Y * deltaLine.Y);
    var c = p1.X * p1.X + p1.Y * p1.Y - circle.radius * circle.radius;


    if (-b < 0) {
        return c < 0 ? true : false;
    }
    if (-b < (2 * a)) {
        return ((4 * a * c - b * b) < 0 ? true : false);
    }

    return (a + b + c < 0 ? true : false);
}

CollisionDetector.isBubbleBubbleCollides = function (bubble1, bubble2) {

    var vecDistance = Vector.magnitude(Vector.sub(bubble2.center, bubble1.center));
    var sumRadius = bubble1.radius + bubble2.radius;
    if (vecDistance <= sumRadius)
        return true;
    else
        return false;
}

/********************* */
