import assert from 'assert';
import romanNumerals from '../roman-numerals';

describe('Array', function() {
  describe('#indexOf()', function() {
    it('should run test', function() {
      assert.equal(romanNumerals.test(), 7);
    });
  });
});