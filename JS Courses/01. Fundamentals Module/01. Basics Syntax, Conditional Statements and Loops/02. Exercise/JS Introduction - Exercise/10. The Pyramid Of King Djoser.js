function pyramidOfKindDjoser(base, heightOfEachStep) {

    let stone = 0;
    let marble = 0;
    let lapis = 0;
    let gold = 0;
    let counter = 1;

    while (base > 2) {
        let outerLayer = 0;
        let total = base * base;
        if (counter % 5 === 0) {
            outerLayer = (4 * base - 4);
            lapis += outerLayer;
            stone += (total - outerLayer);
        } else {
            outerLayer = 4 * base - 4;
            marble += outerLayer;
            stone += (total - outerLayer);
        }
        base -= 2;
        counter++;
    }

    gold = base * base;

    stone = Math.ceil(stone * heightOfEachStep);
    marble = Math.ceil(marble * heightOfEachStep);
    lapis = Math.ceil(lapis * heightOfEachStep);
    gold = Math.ceil(gold * heightOfEachStep);
    totalHeight = Math.floor(counter * heightOfEachStep);

    console.log(`Stone required: ${stone}`);
    console.log(`Marble required: ${marble}`);
    console.log(`Lapis Lazuli required: ${lapis}`);
    console.log(`Gold required: ${gold}`);
    console.log(`Final pyramid height: ${totalHeight}`);
}
pyramidOfKindDjoser(12,
    1
)