var firstOperand = "";
var secondOperand = "";
var operation = "";
var operationPressed = false;
var isCalculated = false;

function B_Operation_Click(op, value)
{
    operationPressed = true;
    operation = op;
    firstOperand = value;
}

function B_Calc_Click(result)
{
    operationPressed = false;
    isCalculated = true;
    secondOperand = result;
    try {
        return Calculate(firstOperand, secondOperand, operation);
    }
    catch (e) {
        if (e.message == "Overflow!") {
            return "Error";
        }
        else if (e.message == "DivisionOnZero!") {
            alert(e);
        }
    }
    
}

function ClearTB(value)
{
    if (operationPressed)
    {
        value = "";
        operationPressed = false;
    }
    if (isCalculated)
    {
        value = "";
        isCalculated = false;
    }
    if (value == "0")
    {
        value = "";
    }
    return value;
}

function NumericButton_Click(number, result)
{
    result = ClearTB(result);
    result += number;
    return result;
}

function Calculate(left, right, sign) {
    var result;
    var x = Number(left);
    var y = Number(right);
    var MAX_INTEGER_VALUE = Math.pow(2, 32);

    switch (sign) {
        case '*':
            {
                result = x * y;
                if (result > MAX_INTEGER_VALUE) {
                    throw new SyntaxError("Overflow!");
                }
                break;
            }

        case '/':
            {
                if (y == 0) {
                    throw new SyntaxError("DivisionOnZero!");
                }
                result = x / y;
                break;
            }

        case '+':
            {
                result = x + y;
                if (result > MAX_INTEGER_VALUE) {
                    throw new SyntaxError("Overflow!");
                }
                break;
            }

        case '-':
            {
                result = x - y;
                break;
            }
    }

    return result;
}