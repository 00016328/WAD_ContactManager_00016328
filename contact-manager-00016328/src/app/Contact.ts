export interface Contact {
    id: number;
    name: string;
    email: string;
    phone: string;
    groupID: number;
    group: {
        id: number;
        name: string;
    };
  }
  