function mergeArrays(arr1, arr2){

    let newArray = new Array();

    for (let i = 0; i < arr1.length; i++) {
        let newElement ;
 
        if(i % 2 == 0) {
            newElement = Number(arr1[i]) + Number(arr2[i]);                        
        } else {
            newElement = arr1[i] + arr2[i];
        }
        newArray.push(newElement);
    }

    console.log(newArray.join(" - "));
}
mergeArrays(['13', '12312', '5', '77', '4'],
['22', '333', '5', '122', '44']

)