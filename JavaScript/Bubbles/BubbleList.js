/* ********************  Bubble list ********************  */
function BubbleList() {

    this.bubbleArray = new Array(0);

    this.add = function (bubble) {

        var newArray = new Array(this.bubbleArray.length + 1);
        for (var i = 0; i < this.bubbleArray.length; i++) {
            newArray[i] = this.bubbleArray[i];
        }
        newArray[this.bubbleArray.length] = bubble;

        this.bubbleArray = newArray;
    }

    this.update = function (Context) {

        for (var i = 0; i < this.bubbleArray.length; i++) {

            this.checkCollision(this.bubbleArray[i]);
            this.bubbleArray[i].Move();
            this.bubbleArray[i].Draw(Context);
        }

    }

    this.checkCollision = function (bubble) {

        bubble.CheckForBorderCollision();
        bubble.CheckForBubbleCollision(this.bubbleArray);
    }
}
/*   ********************      */
