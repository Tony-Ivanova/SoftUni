function login(args) {

    let userName = args[0];
    let reverseUserName = '';
    let count = 0;

    for (let i = userName.length - 1; i >= 0; i--) {
        reverseUserName += `${userName[i]}`;
    }

    let newPass = userName;
    for (let i = 1; i < 5; i++) {
        newPass = args[i];
        if (reverseUserName == newPass) {
            console.log(`User ${userName} logged in.`);
            break;
        }
        else if (reverseUserName != newPass) {
            count++;
            if (count == 4) {
                console.log(`User ${userName} blocked!`);
                break;
            }
            console.log("Incorrect password. Try again.");
        }
    }
}
login(
    ['sunny', 'rainy', 'cloudy', 'sunny', 'not sunny']
)