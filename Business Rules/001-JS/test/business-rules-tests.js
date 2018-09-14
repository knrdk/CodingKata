var assert = require('assert');
var businessRules =  require('../business-rules.js');

describe('Array', function() {
  describe('#indexOf()', function() {
    it('should run test', function() {
      assert.equal(businessRules.test(), 7);
    });
  });
});