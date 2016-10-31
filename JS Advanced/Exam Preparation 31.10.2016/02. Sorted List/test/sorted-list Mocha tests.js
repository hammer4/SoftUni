let expect = require('chai').expect;
let SortedList = require('../sorted-list').SortedList;

describe("SortedList", function () {
   let sortedList;
    beforeEach(() => {sortedList = new SortedList()});
    it("should be empty in the beggining", function () {
        expect(sortedList.size).to.equal(0);
    });
    it("should successfully add elements", function () {
        sortedList.add(5);
        sortedList.add(10);
        expect(sortedList.size).to.equal(2);
        expect(sortedList.get(1)).to.equal(10);
    });
    it("should successfully remove elements", function () {
        sortedList.add(5);
        sortedList.add(10);
        sortedList.add(15);
        sortedList.remove(1);
        expect(sortedList.size).to.equal(2);
        expect(sortedList.get(1)).to.equal(15);
    });
    it("should throw an error on attempt to remove when list is empty", function () {
        sortedList.add(5);
        sortedList.remove(0);
        expect(function() {sortedList.remove(0)}).to.throw("Collection is empty.");
        expect(sortedList.size).to.equal(0);
    });
    it("should throw an error on attempt to remove negative index", function () {
        sortedList.add(5);
        expect(function() {sortedList.remove(-3)}).to.throw("Index was outside the bounds of the collection.");
        expect(sortedList.size).to.equal(1);
    });
    it("should throw an error on attempt to get when list is empty", function () {
        sortedList.add(5);
        sortedList.remove(0);
        expect(function() {sortedList.get(0)}).to.throw("Collection is empty.");
        expect(sortedList.size).to.equal(0);
    });
    it("should throw an error on attempt to get negative index", function () {
        sortedList.add(5);
        expect(function() {sortedList.get(-3)}).to.throw("Index was outside the bounds of the collection.");
        expect(sortedList.size).to.equal(1);
    });
    it("should throw an error on attempt to non-existing negative index", function () {
        sortedList.add(5);
        expect(function() {sortedList.get(1)}).to.throw("Index was outside the bounds of the collection.");
        expect(sortedList.size).to.equal(1);
    });
    it("should sort the elements after add", function () {
        sortedList.add(15);
        sortedList.add(5);
        sortedList.add(10);
        expect(sortedList.get(0)).to.equal(5);
        expect(sortedList.get(2)).to.equal(15);
    });
    it("should have property add", function () {
        expect(SortedList.prototype.hasOwnProperty('add')).to.equal(true)
    });
});