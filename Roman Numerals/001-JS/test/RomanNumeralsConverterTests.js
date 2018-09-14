import assert from 'assert';
import RomanNumeralsConverter from '../RomanNumeralsConverter';

describe('RomanNumeralsConverter', function () {
  describe('#convertToRoman()', function () {
    it('should return nulla for 0', function () {
      ValidateCase(0, 'nulla');
    });

    it('should return \'I\' for 1', function () {
      ValidateCase(1, 'I');
    });

    it('should return \'II\' for 2', function () {
      ValidateCase(2, 'II');
    });

    it('should return \'III\' for 3', function () {
      ValidateCase(3, 'III');
    });

    it('should return \'V\' for 5', function () {
      ValidateCase(5, 'V');
    });

    it('should return \'IV\' for 4', function () {
      ValidateCase(4, 'IV');
    });

    it('should return \'VII\' for 7', function () {
      ValidateCase(7, 'VII');
    });

    it('should return \'IX\' for 9', function () {
      ValidateCase(9, 'IX');
    });

    it('should return \'X\' for 10', function () {
      ValidateCase(10, 'X');
    });

    it('should return \'XX\' for 20', function () {
      ValidateCase(20, 'XX');
    });

    it('should return \'XXIV\' for 24', function () {
      ValidateCase(24, 'XXIV');
    });

    it('should return \'XCVII\' for 97', function () {
      ValidateCase(97, 'XCVII');
    });

    it('should return \'CDXXXVI\' for 436', function () {
      ValidateCase(436, 'CDXXXVI');
    });

    it('should return \'CDXXXVI\' for 436', function () {
      ValidateCase(436, 'CDXXXVI');
    });

    it('should return \'CMXCIX\' for 999', function () {
      ValidateCase(999, 'CMXCIX');
    });

    it('should return \'M\' for 1000', function () {
      ValidateCase(1000, 'M');
    });

    it('should return \'MMM\' for 3000', function () {
      ValidateCase(3000, 'MMM');
    });

    it('should return \'MMMVII\' for 3007', function () {
      ValidateCase(3007, 'MMMVII');
    });

    it('should return \'TOO_BIG\' for 4000', function () {
      ValidateCase(4000, 'TOO_BIG');
    });

    it('should return \'TOO_BIG\' for 8745', function () {
      ValidateCase(8745, 'TOO_BIG');
    });
  });
});

function ValidateCase(input, expectedOutput) {
  const actualResult = RomanNumeralsConverter.convertToRoman(input)
  assert.equal(expectedOutput, actualResult);
}