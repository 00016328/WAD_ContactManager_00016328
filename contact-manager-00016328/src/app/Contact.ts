export interface Contact {
    Id: number;
    Name: string;
    Email: string;
    Phone: string;
    //  group
    Group: {
        GroupId: number;
        GroupName: string;
    }
}
