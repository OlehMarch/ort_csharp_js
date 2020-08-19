window.onload = function () {

    // Get the buttons.
    var dialogBtn = document.getElementById('launchDialog');
    var modalBtn = document.getElementById('launchModal');
    var styledModalBtn = document.getElementById('launchStyledModal');
    var closeBtns = document.querySelectorAll('.close');
    var alertBtn = document.getElementById('alertBox');
    var confirmBtn = document.getElementById('confirmBox');
    var promptBtn = document.getElementById('promptBox');
    // Get the dialogs.
    var dialog = document.getElementById('dialog');
    var modal = document.getElementById('modal');
    var styledModal = document.getElementById('styledModal');
  
    // Setup Event Listeners
    dialogBtn.addEventListener('click', function(e) {
        e.preventDefault();
        dialog.show();
    });
    modalBtn.addEventListener('click', function(e) {
        e.preventDefault();
        modal.showModal();
    });
    styledModalBtn.addEventListener('click', function(e) {
        e.preventDefault();
        styledModal.showModal();
    });
    alertBtn.addEventListener('click', function (e) {
        e.preventDefault();
        alert("I am an alert box!");
    });
    confirmBtn.addEventListener('click', function (e) {
        e.preventDefault();
        var data;
        var res = confirm("Press a button");
        if (res == true) {
            data = "You pressed OK!";
        } else {
            data = "You pressed Cancel!";
        }
        alert(data);
    });
    promptBtn.addEventListener('click', function (e) {
        e.preventDefault();
        var person = prompt("Please enter some text", "Some text");
        if (person != null) {
            alert("There's some text!");
        }
    });
  
    for (var i = 0; i < closeBtns.length; i++) {
    closeBtns[i].addEventListener('click', function(e) {
        this.parentNode.close();
    });
    }
  
};