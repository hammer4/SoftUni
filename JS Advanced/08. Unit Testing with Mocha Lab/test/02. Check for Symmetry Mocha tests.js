let expect = require('chai').expect;
let isSymmetric = require("../02. Check for Symmetry").isSymmetric;

describe("isSymmetric(arr)", function () {
    it("should return true for [1,2,3,3,2,1]", function () {
        expect(isSymmetric([1,2,3,3,2,1])).to.be.equal(true);
    });
    it("should return false for [1,2,3,4,2,1]", function () {
        expect(isSymmetric([1,2,3,4,2,1])).to.be.equal(false);
    });
    it("should return true for [-1,2,-1]", function () {
        expect(isSymmetric([-1,2,-1])).to.be.equal(true);
    });
    it("should return false for [-1,2,1]", function () {
        expect(isSymmetric([-1,2,1])).to.be.equal(false);
    });
    it("should return false for [1,2]", function () {
        expect(isSymmetric([1,2])).to.be.equal(false);
    });
    it("should return true for [1]", function () {
        expect(isSymmetric([1])).to.be.equal(true);
    });
    it("should return true for [5,'hi',{a:5},new Date(),{a:5},'hi',5]", function () {
        expect(isSymmetric([5,'hi',{a:5},new Date(),{a:5},'hi',5])).to.be.equal(true);
    });
    it("should return false for [5,'hi',{a:5},new Date(),{X:5},'hi',5]", function () {
        expect(isSymmetric([5,'hi',{a:5},new Date(),{X:5},'hi',5])).to.be.equal(false);
    });
    it("should return false for 1,2,2,1", function () {
        expect (isSymmetric(1,2,2,1)).to.be.equal(false);
    });
});