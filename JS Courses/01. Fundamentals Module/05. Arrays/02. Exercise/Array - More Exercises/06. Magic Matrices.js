function magic(input){

    let isItEqual = true;
    let firstSum = 0;
    let sumCol = 0; 

    input[0].forEach(x => firstSum += x);    

    for (let row = 1; row < input.length; row++) {
       
        let sumRow = 0; 
        input[row].forEach(x=> sumRow += x);
        
        if(sumRow != firstSum){
            isItEqual = false;        
        }   
    }
    
    for (let col = 0; col < input[0].length; col++) {
        
        for (let row = 0; row < input.length; row++) {
            
            sumCol += input[row][col]; 
        }       
        
        if(firstSum === sumCol){
            isItEqual = true;
        } else{
            isItEqual = false;
            break;
        }
        sumCol = 0;
    }   
   
    console.log(isItEqual);
}