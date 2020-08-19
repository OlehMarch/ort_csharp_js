function OnClick(FO, SO, Op)
{
	var fo = parseFloat(FO);
	var so = parseFloat(SO);
	var res = 0.0;

	switch (Op)
	{
		case "+":
			res = fo + so;
			res = Number(res.toFixed(4));
			break;
		case "-":
			res = fo - so;
			break;
		case "*":
			res = fo * so;
			break;
		case "/":
			res = fo / so;
			break;
		default:
			throw new SyntaxError("SignException");
			break;
			
		res = Number(res.toFixed(4));
	}

	return res;
}