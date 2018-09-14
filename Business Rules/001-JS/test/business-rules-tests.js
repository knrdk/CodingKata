import assert from 'assert';
import businessRules from '../business-rules';

describe('Array', function() {
  describe('#indexOf()', function() {
    it('should run test', function() {
      assert.equal(businessRules.test(), 7);
    });
  });
});