export class Register{
    constructor(
        public name: string,
        public login: string,
        public password: string,
        public isDoctor = true
    ) {}
}