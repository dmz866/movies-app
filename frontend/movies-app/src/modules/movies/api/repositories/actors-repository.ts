import axios from "axios";
import { Actor } from "../../models";

const MOVIE_API_URL = `${process.env?.REACT_APP_MOVIE_API_URL}/actors`;

export const getActorsByName = async (name: string) => {
    return axios.get<Actor[]>(`${MOVIE_API_URL}/search-by/${name}`);
}

export const getActor = async (actorId: number) => {
    return axios.get<Actor>(`${MOVIE_API_URL}/${actorId}`);
}