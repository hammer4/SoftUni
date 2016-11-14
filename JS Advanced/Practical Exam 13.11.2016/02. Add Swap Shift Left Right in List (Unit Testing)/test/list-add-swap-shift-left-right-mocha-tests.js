let expect = require('chai').expect;
let createList = require('../list-add-swap-shift-left-right');

describe("createList", function () {
    let list = {};
    beforeEach(function () {
        list = createList();
    });

    it("should be empty on initialization", function () {
        expect(list.toString()).to.equal("");
    });
    it("should contain methods add, shiftLeft, shiftRight, swap, toString", function () {
        expect(list.add).to.exist;
        expect(list.shiftLeft).to.exist;
        expect(list.shiftRight).to.exist;
        expect(list.swap).to.exist;
        expect(list.toString).to.exist;
    });
    it("should successfully add items of any type", function () {
        list.add(5);
        list.add("pesho");
        list.add(3.14);
        list.add({name:'pesho', age:28});
        expect(list.toString()).to.equal("5, pesho, 3.14, [object Object]")
    });
    it("should shift elements left correctly", function () {
        list.add(5);
        list.shiftLeft();
        expect(list.toString()).to.equal("5");
    });
    it("should shift elements left correctly", function () {
        list.add(5);
        list.add(7);
        list.add("pesho");
        list.shiftLeft();
        expect(list.toString()).to.equal("7, pesho, 5");
    });
    it("should shift elements left multiple times", function () {
        list.add(5);
        list.add(7);
        list.shiftLeft();
        list.add("pesho");
        list.shiftLeft();
        expect(list.toString()).to.equal("5, pesho, 7");
    });
    it("should shift elements right correctly", function () {
        list.add(5);
        list.shiftRight();
        expect(list.toString()).to.equal("5");
    });
    it("should shift elements  right correctly", function () {
        list.add(5);
        list.add(7);
        list.add("pesho");
        list.shiftRight();
        expect(list.toString()).to.equal("pesho, 5, 7");
    });
    it("should shift elements right multiple times", function () {
        list.add(5);
        list.add(7);
        list.shiftRight();
        list.add("pesho");
        list.shiftRight();
        expect(list.toString()).to.equal("pesho, 7, 5");
    });
    it("should return false on swap with incorrect or equal indices", function () {
        list.add(5);
        list.add(7);
        list.add(8);
        expect(list.swap(0, 3)).to.equal(false);
        expect(list.toString()).to.equal("5, 7, 8");
        expect(list.swap(3, 0)).to.equal(false);
        expect(list.toString()).to.equal("5, 7, 8");
        expect(list.swap(-3, 10)).to.equal(false);
        expect(list.toString()).to.equal("5, 7, 8");
        expect(list.swap(10, -3)).to.equal(false);
        expect(list.toString()).to.equal("5, 7, 8");
        expect(list.swap(1.1, 0)).to.equal(false);
        expect(list.toString()).to.equal("5, 7, 8");
        expect(list.swap(0, 1.1)).to.equal(false);
        expect(list.toString()).to.equal("5, 7, 8");
        expect(list.swap(-2, 0)).to.equal(false);
        expect(list.toString()).to.equal("5, 7, 8");
        expect(list.swap(1, -3)).to.equal(false);
        expect(list.toString()).to.equal("5, 7, 8");
        expect(list.swap(0, 4)).to.equal(false);
        expect(list.toString()).to.equal("5, 7, 8");
        expect(list.swap(4, 0)).to.equal(false);
        expect(list.toString()).to.equal("5, 7, 8");
        expect(list.swap(1, 1)).to.equal(false);
        expect(list.toString()).to.equal("5, 7, 8");
        expect(list.swap("2", 0)).to.equal(false);
        expect(list.toString()).to.equal("5, 7, 8");
        expect(list.swap(0, "2")).to.equal(false);
        expect(list.toString()).to.equal("5, 7, 8");
    });
    it("should return true if swapping existing indices", function () {
        list.add(5);
        list.add(7);
        list.add(9);
        list.add(3);
        expect(list.swap(1,3)).to.equal(true);
        expect(list.toString()).to.equal('5, 3, 9, 7');
        expect(list.swap(0, 2)).to.equal(true);
        expect(list.toString()).to.equal('9, 3, 5, 7');
        expect(list.swap(2, 0)).to.equal(true);
        expect(list.toString()).to.equal('5, 3, 9, 7');
        expect(list.swap(3, 1)).to.equal(true);
        expect(list.toString()).to.equal('5, 7, 9, 3');
    });
    it("should work correctly", function () {
        list.add(5);
        list.add("pesho");
        list.add(7);
        list.add(3.12);
        expect(list.toString()).to.equal("5, pesho, 7, 3.12");
        list.shiftLeft();
        list.shiftRight();
        list.shiftRight();
        list.shiftRight();
        expect(list.toString()).to.equal("7, 3.12, 5, pesho");
        list.swap(0, 3);
        list.swap(1, 3);
        list.swap(0, 4);
        list.swap(3, 1);
        expect(list.toString()).to.equal("pesho, 3.12, 5, 7");
    })
});