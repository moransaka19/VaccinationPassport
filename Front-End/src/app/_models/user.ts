import { Pet } from "./pet";
import { Role } from "./role";

export class User {
    id: string;
    name: string;
    login: string;
    password: string;
    roleId: number;
    role: Role;
    pets: Pet[];
}