function OnClick(H, M)
{
	var hours = parseInt(H);
	var minutes = parseInt(M);
	var res = 0.0;

	if (hours > 24 || hours < 0 || minutes < 0 || minutes > 60){
		throw new SyntaxError();
	}
	
	if (hours > 12){
		hours -= 12;
	}
	
	res = (hours + (minutes / 60)) * (360 / 12) - (minutes / 60) * 360;

	res = Number(res.toFixed(2));

	return Math.abs(res);
}