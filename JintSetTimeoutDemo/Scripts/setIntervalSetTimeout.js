﻿function f1() {
    f1.counter++;
    print('Hi 1 - interval - '+f1.counter);
}
f1.counter = 0;
f1.callBackId = setInterval(f1, 500);

function f2() {
    print('Hi 2 - timeout');
}
var timeout2 = setTimeout(f2, 2000);
