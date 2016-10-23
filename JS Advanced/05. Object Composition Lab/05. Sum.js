 function result() {
     let num1, num2, result;
     function init(num1Sel, num2Sel, resultSel) {
         num1 = $(num1Sel);
         num2 = $(num2Sel);
         result = $(resultSel);
     }

     function add() {
         action((a, b) => a + b);
     }

     function subtract() {
         action((a, b) => a - b);
     }

     function action(operation) {
         let val1 = Number(num1.val());
         let val2 = Number(num2.val());
         result.val(operation(val1, val2));
     }

     let model = {init, add, subtract};
        return model;
 };