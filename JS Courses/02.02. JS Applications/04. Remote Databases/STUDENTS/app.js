const htmlSelectors = {

    'loadStudentsBtn': () => document.getElementById('loadStudents'),


    'createBtn': () => document.querySelector('#create-form > button'),
    'createIdNumber': () => document.getElementById('create-id-number'),
    'createFirstName': () => document.getElementById('create-first-name'),
    'createLastName': () => document.getElementById('create-last-name'),
    'createFacultyNumber': () => document.getElementById('create-faculty-number'),
    'createGrade': () => document.getElementById('create-grade'),
    'createForm': () => document.getElementById('create-form'),

    'studentsContainer': () => document.querySelector('table > tbody'),
    'errorContainer': () => document.getElementById('error-notification'),
}

htmlSelectors['loadStudentsBtn']()
    .addEventListener('click', fetchAllStudents);

htmlSelectors["createBtn"]()
    .addEventListener('click', createStudent);

function fetchAllStudents() {
    fetch(`https://students-exercise-808c5.firebaseio.com/Students/.json`)
        .then(res => res.json())
        .then(renderStudents)
        .catch(handleError)
}


function createStudent(e) {
    e.preventDefault();
    const idNumberInput = htmlSelectors['createIdNumber']();
    const firstNameInput = htmlSelectors['createFirstName']();
    const lastNameInput = htmlSelectors['createLastName']();
    const facultyNumberInput = htmlSelectors['createFacultyNumber']();
    const gradeInput = htmlSelectors['createGrade']();

    if (gradeInput.value !== ''
        && idNumberInput.value !== ''
        && firstNameInput.value !== ''
        && lastNameInput.value !== ''
        && facultyNumberInput.value !== '') {
        const inputObj = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                IdNumber: idNumberInput.value,
                FirstName: firstNameInput.value,
                LastName: lastNameInput.value,
                FacultyNumber: facultyNumberInput.value,
                Grade: gradeInput.value,
            })
        }
        fetch('https://students-exercise-808c5.firebaseio.com/Students/.json', inputObj)
            .then(fetchAllStudents)
            .catch(handleError);

        idNumberInput.value = '';
        firstNameInput.value = '';
        lastNameInput.value = '';
        facultyNumberInput.value = '';
        gradeInput.value = '';

    } else {
        const error = { message: '' };

        if (idNumberInput.value === '') {
            error.message += 'Id must not be empty!';
        }

        if (firstNameInput.value === '') {
            error.message += 'First name must not be empty!';
        }

        if (lastNameInput.value === '') {
            error.message += 'Last name must not be empty!';
        }

        if (facultyNumberInput.value === '') {
            error.message += 'Faculty must not be empty!';
        }

        if (gradeInput.value === '') {
            error.message += 'Grade must not be empty!';
        }

        handleError(error);
    }
}


function renderStudents(studentsData) {
    const studentsContainer = htmlSelectors['studentsContainer']();

    if (studentsContainer.innerHTML !== '') {
        studentsContainer.innerHTML = '';
    }


    const array = [];
    Object.keys(studentsData).forEach(studentId => {
        array.push(studentsData[studentId]);


    });
    array.sort((a, b) => a.IdNumber - b.IdNumber);

    array.forEach(x => {
        const { IdNumber, FirstName, LastName, FacultyNumber, Grade } = x;
        const tableRow = createDOMElement('tr', '', {}, {},
            createDOMElement('td', IdNumber, {}, {}),
            createDOMElement('td', FirstName, {}, {}),
            createDOMElement('td', LastName, {}, {}),
            createDOMElement('td', FacultyNumber, {}, {}),
            createDOMElement('td', Grade, {}, {})
        );

        studentsContainer.appendChild(tableRow);
    });
}


function createDOMElement(type, text, attributes, events, ...children) {
    const domElement = document.createElement(type);

    if (text !== '') {
        domElement.textContent = text;
    }

    Object.entries(attributes)
        .forEach(([attrKey, attrValue]) => {
            domElement.setAttribute(attrKey, attrValue)
        });

    Object.entries(events)
        .forEach(([eventKey, eventHandler]) => {
            domElement.addEventListener(eventKey, eventHandler)
        });

    domElement.append(...children);

    return domElement;
}

function handleError(err) {
    const errorContainer = htmlSelectors['errorContainer']();
    errorContainer.style.display = 'block';
    errorContainer.textContent = err.message;

    setTimeout(() => {
        errorContainer.style.display = 'none';
    }, 2000);
}
