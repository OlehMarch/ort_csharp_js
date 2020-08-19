/*  ********************    Bubble   ********************  */
function Bubble(r, c, d) {

    this.radius = r;
    this.center = c;
    this.direction = Vector.normalize(d);
    this.speed = 5;

    this.Move = function () {

        this.center = Vector.add(this.center, Vector.mulSingle(this.direction, this.speed));
    }

    this.Draw = function (Ctx) {
        Ctx.beginPath();
        Ctx.arc(this.center.X, this.center.Y, this.radius, 0, 2 * Math.PI);
        Ctx.stroke();
    }

    this.CheckForBorderCollision = function () {
             // left border
        if (CollisionDetector.isBubbleBorderCollides(this, new Vector(0, 0), new Vector(0, layer.height))) {
            this.direction = Vector.reflect(this.direction, new Vector(1, 0));
        }
            // right border
        else if (CollisionDetector.isBubbleBorderCollides(this, new Vector(layer.width, 0), new Vector(layer.width, layer.height))) {
            this.direction = Vector.reflect(this.direction, new Vector(-1, 0));
        }
            // top border
        else if (CollisionDetector.isBubbleBorderCollides(this, new Vector(0, 0), new Vector(layer.width, 0))) {
            this.direction = Vector.reflect(this.direction, new Vector(0, -1));
        }
            // bottom border
        else if (CollisionDetector.isBubbleBorderCollides(this, new Vector(0, layer.height), new Vector(layer.width, layer.height))) {
            this.direction = Vector.reflect(this.direction, new Vector(0, 1));
        }
    }

    this.CheckForBubbleCollision = function (bubbles) {
        for (var i = 0; i < bubbles.length; i++) {

            if (this == bubbles[i]) {
                continue;
            }
           
            if (CollisionDetector.isBubbleBubbleCollides(this, bubbles[i])) {
                var normal = Vector.sub(this.center, bubbles[i].center);
                normal = Vector.normalize(normal);
                this.direction = Vector.reflect(this.direction, normal);
            }
        }
    }
}

/*    ********************       */