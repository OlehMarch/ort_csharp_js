/*  ****************  Vector  ********************   */
function Vector(x, y) {

    this.X = x;
    this.Y = y;
}

Vector.mulSingle = function (left, right) {
    return new Vector(left.X * right, left.Y * right);
}

Vector.divSingle = function (left, right) {
    return new Vector(left.X / right, left.Y / right);
}

Vector.add = function (left, right) {
    return new Vector(left.X + right.X, left.Y + right.Y);
}

Vector.sub = function (left, right) {
    return new Vector(left.X - right.X, left.Y - right.Y);
}

Vector.mul = function (left, right) {
    return new Vector(left.X * right.X, left.Y * right.Y);
}

Vector.div = function (left, right) {
    return new Vector(left.X / right.X, left.Y / right.Y);
}

Vector.magnitude = function (vec) {
    var length = Math.sqrt(vec.X * vec.X + vec.Y * vec.Y);
    return length;
}

Vector.normalize = function (vec) {
    var normalVec = Vector.divSingle(vec, Vector.magnitude(vec));
    return normalVec;
}

Vector.dot = function (left, right) {
    return ((left.X * right.X) + (left.Y * right.Y));
}

Vector.reflect = function (incident, normal) {

    var normalVec = new Vector(normal.X, normal.Y);
    var n = Vector.mulSingle(normalVec, 2);
    var dotProd = Vector.dot(incident, normalVec);
    var second = Vector.mulSingle(n, dotProd);
    var reflectVec = Vector.sub(incident, second);
    return reflectVec;
}
/*   ********************************  */
