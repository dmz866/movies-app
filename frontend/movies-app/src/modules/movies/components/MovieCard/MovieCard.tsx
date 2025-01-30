import { useCallback } from "react";
import { useNavigate } from "react-router";
import { MOVIE_DETAILS_PATH } from "../../constants";
import { Movie } from "../../models";

type TProps = {
    movie: Movie
};

export const MovieCard = ({ movie }: TProps) => {
    const navigate = useNavigate();
    const navigateToDetails = useCallback(() => {
        navigate(`${MOVIE_DETAILS_PATH}?movieId=${movie.movieId}`);
    }, [movie, navigate]);

    return (
        <div onClick={navigateToDetails} className="hover:cursor-pointer rounded-lg border border-gray-300 bg-black justify-center flex-row p-4 w-64">
            <p className="text-xl font-bold my-2 text-white">{movie.name}</p>
            <img className="mx-auto" alt={movie.name} src={movie.imageUrl || '/images/no-picture.jpg'} height={200} width={200} />
        </div>
    );
};