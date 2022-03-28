function solve(input) {

    const register = {};

    input.forEach(element => {
        let [system, component, subcomponent] = element.split(' | ');
        if (!register[system]) {
            register[system] = {};
        }
        if (!register[system][component]) {
            register[system][component] = [];
        }

        register[system][component].push(subcomponent);
    });

    const sortedSystems = Object.keys(register).sort((a, b) => Object.keys(register[b]).length - Object.keys(register[a]).length || a.localeCompare(b));

    for (const system of sortedSystems) {

        console.log(system);

        const sortedComponents = Object.keys(register[system]).sort((a, b) => register[system][b].length - register[system][a].length);

        for (const component of sortedComponents) {
            console.log(`|||${component}`);
            register[system][component].forEach(x => console.log(`||||||${x}`));
        }
    }
}

solve(['SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security']
)