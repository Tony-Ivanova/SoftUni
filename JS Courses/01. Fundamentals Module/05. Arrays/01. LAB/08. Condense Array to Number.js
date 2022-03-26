function condenseArray(numbers){
            let condensed = Array(numbers.length-1);
            if (numbers.length == 1)
            {
                console.log(numbers[0]);
                return;
            }

            for (let i = 0; i < numbers.length; i++)
            {
                for (let j = 0; j < condensed.length-i; j++)
                {
                    condensed[j] = Number(numbers[j]) + Number(numbers[j + 1]);
                }
                numbers = condensed;
            }
            console.log(condensed[0]);
}
condenseArray([5,0,4,1,2]);