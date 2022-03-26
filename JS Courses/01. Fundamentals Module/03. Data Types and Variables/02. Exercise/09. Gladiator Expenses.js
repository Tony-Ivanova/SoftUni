function gladiatorExpenses(lostFights, helmet, sword, shield, armor) {

    let helmetsToBuy = Math.floor(lostFights / 2);
    let swordsToBuy = Math.floor(lostFights / 3);
    let shieldsToBuy = Math.floor(lostFights / 6);
    let armourToBuy = Math.floor(shieldsToBuy / 2);

    let totalSum = helmetsToBuy * helmet + swordsToBuy * sword + shieldsToBuy * shield + armourToBuy * armor;

    console.log(`Gladiator expenses: ${totalSum.toFixed(2)} aureus`);
}
gladiatorExpenses(23,
    12.50,
    21.50,
    40,
    200

);