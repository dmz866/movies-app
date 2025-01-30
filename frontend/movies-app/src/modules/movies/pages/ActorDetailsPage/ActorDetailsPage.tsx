import { useCallback, useEffect } from 'react';
import { useNavigate, useSearchParams } from "react-router";
import { ClipLoader } from 'react-spinners';
import { BasicContainer } from '../../../common/components';
import { ACTORS_PATH } from "../../constants";
import { useActorDetailsPage } from './useActorDetailsPage';

export const ActorDetailsPage = () => {
    const [search] = useSearchParams();
    const navigate = useNavigate();
    const navigateToActors = useCallback(() => navigate(ACTORS_PATH), []);
    const { isLoading, actor, getActor } = useActorDetailsPage();

    useEffect(() => {
        const id = search.get('actorId') ? +search.get('actorId')! : undefined;

        if (!id || isNaN(id)) navigateToActors();

        getActor(id!);
    }, [search]);

    return (
        <BasicContainer>
            <div className='flex mx-56 pb-10'>
                {
                    (isLoading || !actor) &&
                    <div className='flex justify-center'>
                        <ClipLoader loading={isLoading} size={150} aria-label="Loading Spinner" />
                    </div>
                }
                {
                    actor &&
                    <div className="text-white flex-row p-8 rounded-lg border border-gray-300 gap-4">
                        <p className="text-5xl font-bold mb-8">{actor.name}</p>
                        <div className='flex gap-x-4'>
                            <p className="text-sm font-bold my-4">{actor.description}</p>
                            <img className='rounded-xl' alt={actor.name} src={actor.imageUrl || '/images/no-picture.jpg'} height={300} width={200} />
                        </div>
                        <div className="flex">
                            <div className="flex-row">
                                <p className="text-xl font-bold my-2">Movies</p>
                                {actor.movies?.map((a, indx) => <li key={`${a.name}-${indx}`}>{a.name}</li>)}
                            </div>
                        </div>
                        <div className='flex justify-center mt-5'>
                            <button className="mx-auto w-96 border rounded-lg" onClick={navigateToActors}>Back</button>
                        </div>
                    </div>
                }</div>
        </BasicContainer>
    );
};