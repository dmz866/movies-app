import { useCallback } from "react";
import { useNavigate } from "react-router";
import { ACTOR__DETAILS_PATH } from "../../constants";
import { Actor } from "../../models";

type TProps = {
    actor: Actor
};

export const ActorCard = ({ actor }: TProps) => {
    const navigate = useNavigate();
    const navigateToDetails = useCallback(() => {
        navigate(`${ACTOR__DETAILS_PATH}?actorId=${actor.actorId}`);
    }, [actor, navigate]);

    return (
        <div onClick={navigateToDetails} className="hover:cursor-pointer rounded-lg border border-gray-300 bg-black justify-center flex-row p-4 w-64">
            <p className="text-xl font-bold my-2 text-white">{actor.name}</p>
            <img className="mx-auto" alt={actor.name} src={actor.imageUrl || '/images/no-picture.jpg'} height={200} width={200} />
        </div>
    );
};