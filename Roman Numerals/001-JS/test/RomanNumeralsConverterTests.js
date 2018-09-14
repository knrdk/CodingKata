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
  });
});

function ValidateCase(input, expectedOutput) {
  const actualResult = RomanNumeralsConverter.convertToRoman(input)
  assert.equal(expectedOutput, actualResult);
}