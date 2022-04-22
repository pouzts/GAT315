using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulator : Singleton<Simulator>
{
	[SerializeField] BoolData simulate;
	[SerializeField] IntData fixedFPS;
	[SerializeField] StringData fps;
	[SerializeField] List<Force> forces;

	public List<Body> bodies { get; set; } = new List<Body>();
	Camera activeCamera;

	public float fixedDeltaTime => 1f / fixedFPS.value;
	float timeAccumulator = 0;

	private void Start()
	{
		activeCamera = Camera.main;
	}

	private void Update()
	{
		if (!simulate.value)
			return;

		timeAccumulator += Time.deltaTime;

		forces.ForEach(force => force.ApplyForce(bodies));

		while (timeAccumulator > fixedDeltaTime)
		{
			//bodies.ForEach(body => body.shape.color = Color.white);
			Collision.CreateContacts(bodies, out var contacts);
			/*contacts.ForEach(contact => 
			{
				contact.bodyA.shape.color = Color.red;
				contact.bodyB.shape.color = Color.red;
			});*/

			Collision.SeparateContacts(contacts);
			Collision.ApplyImpulses(contacts);

			bodies.ForEach(body =>
			{ 
				Integrator.SemiImplicitEuler(body, Time.deltaTime);
			});
			
			timeAccumulator -= fixedDeltaTime;
		}

		bodies.ForEach(body => body.acceleration = Vector2.zero);
		
		// get fps
		fps.value = (1f / Time.deltaTime).ToString("##.#");
    }

    public Vector3 GetScreenToWorldPosition(Vector2 screen)
	{
		Vector3 world = activeCamera.ScreenToWorldPoint(screen);
		return world;
	}

	public Body GetScreenToBody(Vector3 screen)
	{
		Body body = null;

		Ray ray = activeCamera.ScreenPointToRay(screen);
		RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

		if (hit.collider) 
		{
			hit.collider.gameObject.TryGetComponent<Body>(out body);
		}

		return body;
	}

	public void Clear()
    {
		bodies.ForEach(body => Destroy(body.gameObject));
		bodies.Clear();
    }
}
