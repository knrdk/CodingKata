function convertToRoman(decimalNumber){
    var result = convertDigitToRoman(decimalNumber)

    if(result === ""){
        result = "nulla";
    }
    return result;
}

// I know that 10 is not a digit
// however I haven't came up with better name for this function
function convertDigitToRoman(digit) {
    if (digit === 0) {
        return '';
    }
    if (digit < 4){
        return repeatChar(digit);
    }
    if(digit === 4){
        return 'IV';
    }
    if(digit < 9){
        return 'V' + repeatChar(digit - 5);
    }
    if(digit === 9){
        return 'IX';
    }
    return 'X';
}

function repeatChar(count){
    return [...Array(count).keys()].map(x => 'I').join('');
}

export default {
    convertToRoman
};