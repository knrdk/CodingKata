const LEVELS = [['I', 'V', 'X'], ['X', 'L', 'C'], ['C', 'D', 'M'], ['M']];
const INVALID_NUMBER_CHARACTER = '@';

// const 
function convertToRoman(decimalNumber) {
    var result = '';

    var level = 0;
    var remainingPart = decimalNumber;
    while (remainingPart > 0 && level < LEVELS.length) {
        var lastDigit = getLastDigit(remainingPart);
        var result = convertDigitToRoman(lastDigit, LEVELS[level]) + result;
        remainingPart = getNumberWithoutLastDigit(remainingPart);
        level++;
    }

    if (result === "") {
        return "nulla";
    } else if(result.indexOf(INVALID_NUMBER_CHARACTER)>-1){
        return "TOO_BIG";
    }
    return result;
}

function getLastDigit(number) {
    return Number(number.toString().slice(-1));
}

function getNumberWithoutLastDigit(number) {
    if (number < 10) {
        return 0;
    }
    const asString = number.toString();
    return Number(asString.substring(0, asString.length - 1));
}

// I know that 10 is not a digit
// however I haven't came up with better name for this function
function convertDigitToRoman(digit, romanDigits) {
    if (digit === 0) {
        return '';
    }
    if (digit < 4) {
        return repeatChar(digit, romanDigits[0]);
    }

    if(romanDigits.length < 2){
        return INVALID_NUMBER_CHARACTER;
    }

    if (digit === 4) {
        return romanDigits[0] + romanDigits[1];
    }
    if (digit < 9) {
        return romanDigits[1] + repeatChar(digit - 5, romanDigits[0]);
    }
    if (digit === 9) {
        return romanDigits[0] + romanDigits[2];
    }

    return INVALID_NUMBER_CHARACTER;
}

function repeatChar(count, char) {
    return [...Array(count).keys()].map(x => char).join('');
}

export default {
    convertToRoman
};