import { UserStatus } from "./UserStatus"
import { UserRole } from "./UserRole"

export class User{
    // NOTE: THIS IS THE REAL USER
    userId!: number;
    statusId?: number;
    userStatus!: UserStatus;
    roleId?: number;
    role!: UserRole;
    username!: string;
    password!: string;
    firstName!: string;
    lastName!: string;
    email!: string;
    dateCreated!: Date;
    imageUrl!: string;
    isArchived?: boolean;


    // NOTE: Temporary user for auth.service login
    // email!: string;
    // userId!: string;
}