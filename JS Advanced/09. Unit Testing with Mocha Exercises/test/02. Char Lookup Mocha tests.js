let expect = require('chai').expect;
let should = require('chai').should();
let lookupChar = require('../02. Char Lookup').lookupChar;

describe("lookupChar", function () {
    it('with a non-string first parameter should return undefined', function () {
        expect(lookupChar(13, 0)).to.equal(undefined, "The function did not return correct result");
    });
    it('with a non-string second parameter should return undefined', function () {
        expect(lookupChar("pesho", "gosho")).to.equal(undefined, "The function did not return correct result");
    });
    it('with a floating point number second parameter should return undefined', function () {
        expect(lookupChar("pesho", 3.12)).to.equal(undefined, "The function did not return correct result");
    });
    it('with an incorrect index value should return incorrect index', function () {
        expect(lookupChar("gosho", 13)).to.equal("Incorrect index", "The function did not return correct result");
    });
    it('with a negative index value should return incorrect index', function () {
        expect(lookupChar("stamat", -1)).to.equal("Incorrect index", "The function did not return correct result");
    });
    it('with an index value equal to string length, should return incorrect index', function () {
        expect(lookupChar("pesho", 5)).to.equal("Incorrect index", "The function did not return correct result");
    });
    it('with correct parameters, should return correct value', function () {
        expect(lookupChar("pesho", 0)).to.equal("p", "The function did not return correct result");
    });
    it('with correct parameters should return correct value', function () {
        expect(lookupChar("stamat", 3)).to.equal("m", "The function did not return correct result");
    });
});