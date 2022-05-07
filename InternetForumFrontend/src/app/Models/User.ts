import { UserStatus } from "./UserStatus"
import { UserRole } from "./UserRole"

export class User{
    // NOTE: THIS IS THE REAL USER
    userId!: number;
    userStatusId?: number;
    userStatus!: UserStatus;
    userRoleId?: number;
    userRole!: UserRole;
    username!: string;
    password!: string;
    firstName!: string;
    lastName!: string;
    email!: string;
    dateCreated!: Date;
    imageUrl!: string;


    // NOTE: Temporary user for auth.service login
    // email!: string;
    // userId!: string;
}