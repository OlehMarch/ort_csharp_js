function PowLoop(v, d)
{
	var degree = parseInt(d);
	var value = parseInt(v);
	var res = value;
	
	for (var i = 1; i <= degree; i++)
	{
		res *= value;
	}
	return res;
}

function PowRecursion(value, degree)
{
	return recursion(parseInt(value), parseInt(degree), 1);
}

function recursion(value, degree, res){
	if (degree === 0){
		return res;
	}
	return recursion(value, degree - 1, res*value);
}