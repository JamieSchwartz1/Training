//credit Craig Coles
let sweetCounter = 0;
let saltyCounter = 0;
let snsCounter = 0; //%15
var array = new Array();
for(var i = 1; i<=1000; i++){
    if(i % 15 == 0){
        ++snsCounter;
        array.push("SweetNSalty");
    }
    else if(i%5 == 0){
        ++saltyCounter;
        array.push("Salty");
    }
    else if(i%3 == 0){
        ++sweetCounter;
        array.push("Sweet");
    }
    else{
        array.push(i);
    }
    if(i % 20 == 0){
        console.log(array.toString());
        console.log("\n");
        array = [];
    }
}