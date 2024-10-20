import { json } from "stream/consumers";

export interface SingletRequest{
    title: string;
    description: string;
    price: number;
}

export const getAllSinglets = async () => {
    const response = await fetch("https://localhost:7067/Singlet");

    return response.json();
}

export const createSinglet = async (singletRequest: SingletRequest) => {
    await fetch("https://localhost:7067/Singlet", {
        method: "POST",
        headers: {
            "content-type": "application/json",
        },
        body: JSON.stringify(singletRequest),
    });
   
};

export const updateSinglet = async (id: string, singletRequest: SingletRequest) => {

    await fetch(`https://localhost:7067/Singlet/${id}`, {
        method: "PUT",
        headers: {
            "content-type": "application/json",
        },
        body: JSON.stringify(singletRequest),
    });

}

export const deleteSinglet = async (id: string) => {

    await fetch(`https://localhost:7067/Singlet/${id}`, {
        method: "DELETE",
    });

}