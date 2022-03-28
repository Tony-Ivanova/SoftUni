function solveClasses() {

    class Developer {
        constructor(firstName, lastName) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.baseSalary = 1000;
            this.tasks = [];
            this.experience = 0;
        }

        addTask(id, taskName, priority) {
            let task = {
                id: Number(id),
                taskName,
                priority
            }

            if (priority === 'high') {
                this.tasks.unshift(task);
            } else {
                this.tasks.push(task);
            }

            return `Task id ${id}, with ${priority} priority, has been added.`
        }

        doTask() {
            let message = `${this.firstName}, you have finished all your tasks. You can rest now.`;
            if (this.tasks.length == 0) {
                return message;
            }

            let taskToRemove = this.tasks.shift();
            return taskToRemove.taskName;
        }

        getSalary() {
            return `${this.firstName} ${this.lastName} has a salary of: ${this.baseSalary}`;
        }

        reviewTasks() {
            let result = `Tasks, that need to be completed:`;

            if (this.tasks.length != 0) {
                for (let i = 0; i < this.tasks.length; i++) {
                    let currentTask = this.tasks[i];
                    result += '\n';
                    result += `${currentTask.id}: ${currentTask.taskName} - ${currentTask.priority}`;
                }
            }

            return result;
        }
    }


    class Junior extends Developer {
        constructor(firstName, lastName, bonus, experience) {
            super(firstName, lastName);
            this.baseSalary = 1000 + Number(bonus);
            this.tasks = [];
            this.experience = Number(experience);
        }

        learn(years) {
            return this.experience += Number(years);
        }
    }

    class Senior extends Developer {
        constructor(firstName, lastName, bonus, experience) {
            super(firstName, lastName);
            this.baseSalary = 1000 + Number(bonus);
            this.tasks = [];
            this.experience = Number(experience) + 5;
        }

        changeTaskPriority(taskId) {
            let currentTask = this.tasks.find(x => x.id == taskId);
            this.tasks.splice(1, 0, currentTask);
            if (currentTask.priority === 'high') {
                currentTask.priority = 'low';
                this.tasks.push(currentTask);
            } else {
                currentTask.priority = 'high';
                this.tasks.unshift(currentTask);
            }

            return currentTask;
        }
    }

    return {
        Developer,
        Junior,
        Senior
    }
}