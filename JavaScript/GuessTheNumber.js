var number = 0;
var attempts = 10;
var oldValue = 0;

function OnClick(Value)
{
	var value = parseInt(Value);
	
	if (value < 1 || value > 100 || value == null){
		throw new SyntaxError("Wrong argument!");
	}
	
	if (attempts === -1){
		alert("You loose. It was " + number);
	}
	else if (attempts >= 0 && number === value){
		alert("You won");
	}
	else if (attempts === 10){
		oldValue = value;
		attempts -= 1;
	}
	else if (attempts > 0 && Math.abs(number - value) > Math.abs(number - oldValue)){
		alert("Colder");
	}
	else if (attempts > 0 && Math.abs(number - value) < Math.abs(number - oldValue)){
		alert("Hotter");
	}
	else if (attempts > 0 && Math.abs(number - value) == Math.abs(number - oldValue)){
		alert("Neither colder nor hotter");
	}
	
	document.getElementById("attemptCounter").innerHTML = attempts + " attempt(s) left";
	oldValue = value;
	attempts -= 1;
}

function GenerateNumber(){
	number = Math.floor(Math.random() * (100 - 1 + 1)) + 1;
}